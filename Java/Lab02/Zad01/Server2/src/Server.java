import org.apache.xmlrpc.WebServer;

public class Server {
    public static void main(String[] args) {
        try {
            System.out.println("Server XML-RPC is starting...");
            int port = 10_011;
            WebServer server = new WebServer(port);
            server.addHandler("MyServer", new Server());
            server.start();
            System.out.println("Server is running.");
            System.out.println("Listening on port: " + port);
            System.out.println("To change the configuration pres crl+c");
        } catch(Exception e) {
            System.err.println("Server: " + e);
        }
    }

    public Integer echo(int x, int y) {
        return x + y;
    }

    public Integer executeAsync(int time) {
        System.out.println("Called asynchronously");
        System.out.println("Counting down...");
        try {
            Thread.sleep(time);
        } catch(InterruptedException e) {
            e.printStackTrace();
            Thread.currentThread().interrupt();
        }
        System.out.println("Done");
        return time;
    }
}
