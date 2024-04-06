package Metier;
import DAO.IDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;

@Component
public class MetierImp implements IMetier {

   //couplage faible
    @Autowired
    @Qualifier("dao")
    private IDao dao;
//   public MetierImp(IDao dao)
//    {
//        this.dao=dao;
//    }
    @Override
    public double calcul() {

        double temp=dao.getData();
        double resultat=temp*Math.PI;
        return resultat;
    }
    //injecter dans la variable dao un objet de type IDao

    public void setDao(IDao dao)
    {
        this.dao=dao;
    }
}
