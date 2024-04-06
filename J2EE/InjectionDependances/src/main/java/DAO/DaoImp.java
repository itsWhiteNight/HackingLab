package DAO;

import org.springframework.stereotype.Component;

@Component("dao")
public class DaoImp implements IDao{
    @Override
    public double getData() {

        // recuperer la temperature depuis la base de donnee
        System.out.println(" depuis la Base de données :");
        double temp=Math.random()*40;

        return temp;
    }
}
