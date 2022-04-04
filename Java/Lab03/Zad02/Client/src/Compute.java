import java.rmi.Remote;
import java.rmi.RemoteException;
import java.io.Serializable;

public interface Compute extends Remote, Serializable {
    <T> T executeTask(Task<T> task) throws RemoteException;
}
