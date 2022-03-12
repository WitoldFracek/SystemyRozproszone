import org.apache.xmlrpc.WebServer;

public class Server {

    public static void main(String[] args) {
        int port = 10_011;
        System.out.println("Server XML-RPC is starting...");
        String serverId = "RSI_ZAD2";
        try {
            WebServer server = new WebServer(port);
            server.addHandler(serverId, new Server());
            server.start();
            System.out.println("Server is running.");
            System.out.println("Listening on port: " + port);
            System.out.println("To change the configuration press crl+c");
        } catch(Exception e) {
            System.err.println("Server" + e);
        }
    }

    public String show() {
        String ret = """
                show() -> returns this message.
                calculateBmi(double mass, double height) -> returns BMI (double).
                getPyramidAsync(int height, char symbol) -> return a string pyramid made out of given symbol.
                triangleSurface(double a, double b, double c) -> returns a surface of specified triangle (double).
                """;
        return ret;
    }

    public String getPyramidAsync(int height, char symbol) {
        String spaces = " ".repeat(height - 1);
        StringBuilder ret = new StringBuilder();
        for(int i=0; i<height; i++) {
            ret.append(spaces);
            ret.append(symbol);
            ret.append('\n');
            spaces = spaces.substring(0, spaces.length() - 1);
        }
        return ret.toString();
    }

    public Double calculateBMI(double mass, double height) {
        return mass / (height * height);
    }

    public Double triangleSurface(double a, double b, double c) {
        double p = (a + b + c) / 2;
        return Math.sqrt(p * (p - a) * (p - b) * (p - c));
    }
}
