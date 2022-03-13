import org.apache.xmlrpc.XmlRpcClient;
import java.util.Vector;

public class Client {
    public static void main(String[] args) {

        var callback = new MyCallback();
        int port = 10_011;
        var params = new Vector<Integer>();
        params.addElement(1);
        params.addElement(3);

        var params2 = new Vector<Integer>();
        params2.addElement(3000);
        try {
            XmlRpcClient client = new XmlRpcClient("http://localhost:" + port);
            Object result = client.execute("MyServer.echo", params);
            int res = (Integer) result;
            System.out.println("Result: " + res);
            System.out.println();
            client.executeAsync("MyServer.executeAsync", params2, callback);
            System.out.println("Asynchronous callback test");
        } catch(Exception e) {
            System.err.println("Client: " + e);
        }

    }
}
