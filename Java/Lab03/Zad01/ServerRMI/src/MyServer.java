import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class MyServer {
    public static void main(String[] args) {

        MyData.info();

        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        }


        if (System.getSecurityManager() == null) {
                System.getSecurityManager();
        }

        try {
            Registry reg = LocateRegistry.createRegistry(1099);
        } catch (RemoteException e1) {
            e1.printStackTrace();
        }
        try {
            CalcObjImpl objImpl = new CalcObjImpl();
            java.rmi.Naming.rebind(args[0], objImpl);
            CalcObjImpl2 objImpl2 = new CalcObjImpl2();
            //tez nie pewna tego
            java.rmi.Naming.rebind(args[1], objImpl2);
            System.out.println("Server is registered now :)");
            System.out.println("Press Ctrl+C to stop...");
        } catch (Exception e) {
            System.out.println("SERVER CAN'T BE REGISTERED!");
            e.printStackTrace();
            return;
        }
    }
}
