package metier;
import dao.IDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component("metier")
public class MetierImpl implements IMetier {
    // Couplage faible
    @Autowired
    private IDao dao;

    @Override
    public int calcul(int a, int b) {
        String date = dao.getDate();
        return a + b + Integer.parseInt(date.replaceAll("-", ""));
    }

    public void setDao(IDao dao) {
        this.dao = dao;
    }
}
