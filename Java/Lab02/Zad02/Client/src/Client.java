import org.apache.xmlrpc.XmlRpcClient;
import org.apache.xmlrpc.XmlRpcException;

public class Client {

    public static void main(String[] args) {
        ConsoleController cc = new ConsoleController();
        String serverId = "RSI_ZAD2";
        PyramidCallback pc = new PyramidCallback();

        cc.print("Enter server IP:");
        String serverIp = cc.loadString();

        cc.print("Enter server port:");
        int port = cc.loadInt();

        cc.clearBuffer();

        try {
            XmlRpcClient client = new XmlRpcClient(serverIp + ":" + port);
            cc.print("Connected to: " + client.getURL());

            while(true) {
                while (!cc.isReady) {
                    System.out.print("==>");
                    cc.input();
                }
                String method = cc.getMethod();
                var params = cc.getBuffer();
                try {
                    if (cc.isAsync) {
                        client.executeAsync(serverId + "." + method, params, pc);
                    } else {
                        var result = client.execute(serverId + "." + method, params);
                        System.out.println(result);
                    }
                } catch(XmlRpcException e) {
                    System.err.println(e + "\nMaybe you're missing a parameter?");
                }
                cc.clear();
            }
//            String result = (String)client.execute(serverId + ".show", new Vector<>());
//            System.out.println("\n" + result);
//
//
//            var bmiParams = new Vector<Double>();
//            bmiParams.addElement(67.0);
//            bmiParams.addElement(1.87);
//            double bmi = (double)client.execute(serverId + ".calculateBMI", bmiParams);
//            System.out.println("BMI: " + bmi);
//
//            var triangleParams = new Vector<Double>();
//            triangleParams.addElement(3.0);
//            triangleParams.addElement(4.0);
//            triangleParams.addElement(5.0);
//            double surface = (double)client.execute(serverId + ".triangleSurface", triangleParams);
//            System.out.println("Surface: " + surface);
//
//            AsyncCallback callback = new Callback();
//            var pyramidParams = new Vector<>();
//            pyramidParams.addElement(5);
//            pyramidParams.addElement("#");
//            client.executeAsync(serverId + ".getPyramidAsync", pyramidParams, callback);
        } catch(Exception e) {
            System.err.println("Client: " + e);
        }
    }

}
