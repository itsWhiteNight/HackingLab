package DAO;

import org.springframework.stereotype.Component;

@Component("dao2")
public class DaoImp2 implements IDao{
    @Override
    public double getData() {

        // recuperer la temperature depuis la base de donnee
        System.out.println(" depuis le capteur de température :");
        double temp=Math.random()*40;

        return temp;
    }
}
