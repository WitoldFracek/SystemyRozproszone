import org.apache.xmlrpc.AsyncCallback;

import java.net.URL;

public class Callback implements AsyncCallback {

    @Override
    public void handleResult(Object result, URL url, String method) {
        String res = (String)result;
        System.out.println("\n" + res);
    }

    @Override
    public void handleError(Exception error, URL url, String method) {
        System.err.println(error.toString());
    }
}
