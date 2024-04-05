# Exemple d'utilisation d'injection de dépendances en Java

## 1. Créer l'interface IDao avec une méthode getDate :

```java
// IDao.java
public interface IDao {
    String getDate();
}
```

## 2. Créer une implémentation de cette interface :

```java
public class DaoImpl implements IDao {
    @Override
    public String getDate() {
        return "05-04-2024"; // Date fictive
    }
}
```

## 3. Créer l'interface IMetier avec une méthode calcul :

```java
public interface IMetier {
    void calcul();
}
```

## 4. Créer une implémentation de cette interface en utilisant le couplage faible :

```java
public class MetierImpl implements IMetier {
    private IDao dao;

    public MetierImpl(IDao dao) {
        this.dao = dao;
    }

    @Override
    public void calcul() {
        String date = dao.getDate();
        // Logique de calcul avec la date
        System.out.println("Date reçue de la DAO : " + date);
    }
}
```

## 5. Injection des dépendances :

### a. Par instanciation statique :

```java 
public class Main {
    public static void main(String[] args) {
        IDao dao = new DaoImpl();
        IMetier metier = new MetierImpl(dao);
        metier.calcul();
    }
}
```

### b. Par instanciation dynamique :


```java
public class Main {
    public static void main(String[] args) {
        IDao dao = new DaoImpl();
        IMetier metier = new MetierImpl(dao);
        metier.calcul();

        // Changement de l'implémentation de IDao à la volée
        dao = new AnotherDaoImpl();
        ((MetierImpl) metier).setDao(dao);
        metier.calcul();
    }
}
```

### c. En utilisant le Framework Spring :

#### Version XML
```xml 
<beans>
    <bean id="dao" class="com.example.DaoImpl" />
    <bean id="metier" class="com.example.MetierImpl">
        <constructor-arg ref="dao" />
    </bean>
</beans>
```

#### versions annotations 
```MetierImpl.java
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class MetierImpl implements IMetier {
    private IDao dao;

    @Autowired
    public MetierImpl(IDao dao) {
        this.dao = dao;
    }

    @Override
    public void calcul() {
        String date = dao.getDate();
        // Logique de calcul avec la date
        System.out.println("Date reçue de la DAO : " + date);
    }
}
```









