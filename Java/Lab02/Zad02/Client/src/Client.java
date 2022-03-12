import org.apache.xmlrpc.AsyncCallback;
import org.apache.xmlrpc.XmlRpcClient;
import java.util.Vector;
import java.net.MalformedURLException;

public class Client {

    public static void print(Object obj) {
        System.out.println(obj);
    }

    public static void main(String[] args) {
        int port = 10_011;
        String serverId = "RSI_ZAD2";
        try {
            XmlRpcClient client = new XmlRpcClient("http://localhost:" + port);
            print("Connected to: " + client.getURL());
            print("");

            String result = (String)client.execute(serverId + ".show", new Vector<>());
            System.out.println("\n" + result);


            var bmiParams = new Vector<Double>();
            bmiParams.addElement(67.0);
            bmiParams.addElement(1.87);
            double bmi = (double)client.execute(serverId + ".calculateBMI", bmiParams);
            System.out.println("BMI: " + bmi);

            var triangleParams = new Vector<Double>();
            triangleParams.addElement(3.0);
            triangleParams.addElement(4.0);
            triangleParams.addElement(5.0);
            double surface = (double)client.execute(serverId + ".triangleSurface", triangleParams);
            System.out.println("Surface: " + surface);

            AsyncCallback callback = new Callback();
            var pyramidParams = new Vector<>();
            pyramidParams.addElement(5);
            pyramidParams.addElement("#");
            client.executeAsync(serverId + ".getPyramidAsync", pyramidParams, callback);
        } catch(Exception e) {
            System.err.println("Client: " + e);
        }
    }

}
