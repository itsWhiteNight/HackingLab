package Presentation;

import DAO.DaoImp;
import Metier.MetierImp;

public class Presentation {

    public static void main(String []args)
    {
        /*
        Injection des dependances par instanciation statique
        ==>new
         */
        DaoImp dao=new DaoImp();
        MetierImp metier=new MetierImp();
        metier.setDao(dao);
        System.out.println("Resultat = "+metier.calcul());
    }
}
