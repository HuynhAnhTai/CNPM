/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab09;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

/**
 *
 * @author HP
 */
public class Lab09 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws InterruptedException {
        // TODO code application logic here
        System.setProperty("webdriver.chrome.driver", "E:\\CNPM\\lab9\\Lab09\\src\\lab09\\chromedriver.exe");
        
        //ex12();
        ex3();
    }
    
    public static void ex12(){
        WebDriver driver = new ChromeDriver();
        driver.get("https://elit.tdtu.edu.vn/"); // mở sakai
        
        WebElement username = driver.findElement(By.id("pseudonym_session_unique_id"));
        WebElement password = driver.findElement(By.id("pseudonym_session_password"));
        WebElement loginButton = driver.findElement(By.xpath("//*[@id=\"login_form\"]/div[3]/div[2]/button"));
        
        username.sendKeys("123465");
        password.sendKeys("hellu");
        loginButton.click();
    }
    
    public static void ex3() throws InterruptedException{
        WebDriver driver = new ChromeDriver();
        driver.get("http://www.tinyupload.com/");
        
        WebElement file = driver.findElement(By.name("uploaded_file"));
        WebElement button = driver.findElement(By.xpath("/html/body/table/tbody/tr[4]/td/table/tbody/tr/td[2]/form/table/tbody/tr[2]/td[1]/img"));
        Thread.sleep(2000);
        file.sendKeys("C:\\Users\\HP\\Desktop\\51702171.txt");
        Thread.sleep(2000);
        button.click();
        Thread.sleep(6000);
        WebElement url = driver.findElement(By.xpath("/html/body/table/tbody/tr[4]/td/table/tbody/tr/td[2]/a[1]"));
        
        System.out.println(url.getText());
    }
    
}
