import android.os.Build;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class SocUtils {
    public static String getSocInfo(){
        String socModel=getSocModel();
        String socPlatform=getSocPlatform();
        String socHardware=getSocHardware();
        return socModel+"#"+socPlatform+"#"+socHardware;
    }
    public static String getSocModel() {
        String soc = getSystemProperty("ro.soc.model");
        return soc;
    }

    public static String getSocPlatform(){
        String platform = getSystemProperty("ro.board.platform");
        return platform;
    }

    public static String getSocHardware(){
        String hardware = getSystemProperty("ro.hardware");
        if (hardware != null && !hardware.isEmpty())
            return hardware;
        return Build.HARDWARE;
    }

    private static String getSystemProperty(String key) {
        try {
            Process process = Runtime.getRuntime().exec("getprop " + key);
            BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream()));
            String line = reader.readLine();
            reader.close();
            return line != null ? line.trim() : "";
        } catch (Exception e) {
            return "";
        }
    }
}