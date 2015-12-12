package com.cap.seetest.demo;

import com.experitest.client.*;
import org.junit.*;
/**
 *
*/
public class SeetestDemo {
    private String host = "localhost";
    private int port = 8889;
    private String projectBaseDirectory = "/Users/xcj600/workspace/project2";
    protected Client client = null;

    @Before
    public void setUp(){
        client = new Client(host, port, true);
        client.setProjectBaseDirectory(projectBaseDirectory);
        client.setReporter("xml", "reports", "Untitled");
    }

    @Test
    public void testUntitled(){
        // it is recommended to start your script with SetDevice command:
    	client.setDevice("ios_app:Test");
        client.uninstall("com.experitest.ExperiBank");
    	client.install("com.experitest.ExperiBank", true, false);   
    	client.launch("com.experitest.ExperiBank", true, false);
    	client.sleep(5000);
        client.verifyElementFound("LoginPage", "userName", 0);
        client.verifyElementFound("LoginPage", "passWord", 0);
        client.verifyElementFound("LoginPage", "login", 0);
        client.click("LoginPage", "userName", 0, 1);
        client.sendText("company");
        client.click("LoginPage", "passWord", 0, 1);
        client.sendText("company");
        client.click("LoginPage", "login", 0, 1);
    }

    @After
    public void tearDown(){
        // Generates a report of the test case.
        // For more information - https://docs.experitest.com/display/public/SA/Report+Of+Executed+Test
        client.generateReport(false);
        // Releases the client so that other clients can approach the agent in the near future. 
        client.releaseClient();
    }
}
