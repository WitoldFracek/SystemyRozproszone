import java.awt.*;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.math.BigDecimal;
import java.io.File;

public class ComputePi {

    @SuppressWarnings("removal")
    public static void main(String[] args) {
//        File f = new File(".");
//        File[] list = f.listFiles();
//        for(File file: list) {
//            if(file.isFile()) {
//                System.out.println(file.getName());
//            }
//        }
        if(System.getSecurityManager() == null) {
            System.setSecurityManager(new SecurityManager());
        }

        try {
            String name = "Compute";
            Registry registry = LocateRegistry.getRegistry(args[0]);
            Compute comp = (Compute) registry.lookup(name);
            Pi task = new Pi(Integer.parseInt(args[1]));
            BigDecimal pi = comp.executeTask(task);
            System.out.println(pi);
        } catch(Exception e) {
            System.err.println("ComputePi exception:");
            e.printStackTrace();
        }
    }

}
