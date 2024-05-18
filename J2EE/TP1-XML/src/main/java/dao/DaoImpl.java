package dao;

import org.springframework.stereotype.Component;

@Component("dao")
public class DaoImpl implements IDao{
    @Override
    public String getDate() {
        return "2024-04-04";
    }
}
