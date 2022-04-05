import java.io.Serial;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;

// -Djava.rmi.server.hostname=localhost -Djava.security.policy=out\production\Server\srv.policy
public class ComputeEngine implements Compute {

    @Serial
    private static final long serialVersionUID = 103L;

    public ComputeEngine() {
        super();
    }

    @Override
    public <T> T executeTask(Task<T> task) throws RemoteException {
        return task.execute();
    }

    @SuppressWarnings("removal")
    public static void main(String[] args) {
//        if(System.getSecurityManager() == null) {
//            System.setSecurityManager(new SecurityManager());
//        }

        try {
            String name = "Compute";
            Compute engine = new ComputeEngine();
            Compute stub = (Compute) UnicastRemoteObject.exportObject(engine, 0);
//            Registry registry = LocateRegistry.getRegistry();
            Registry registry = LocateRegistry.createRegistry(1099);
            registry.rebind(name, stub);
            System.out.println("ComputeEngine bound");
        } catch (Exception e) {
            System.err.println("ComputeEngine exception:");
            e.printStackTrace();
        }
    }
}
