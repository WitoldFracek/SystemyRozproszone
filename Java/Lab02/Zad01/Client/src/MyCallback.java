import org.apache.xmlrpc.AsyncCallback;

import java.net.URL;

public class MyCallback implements AsyncCallback {

    @Override
    public void handleResult(Object result, URL url, String method) {
        System.out.println("handleResult");
        System.out.println(method);
    }

    @Override
    public void handleError(Exception error, URL url, String method) {
        System.err.println("handleError");
    }
}
