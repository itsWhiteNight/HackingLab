package ma.emsi.ormdemo;

import ma.emsi.ormdemo.entities.Product;
import ma.emsi.ormdemo.repository.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.util.List;

@SpringBootApplication
public class OrmDemoApplication implements CommandLineRunner {
    @Autowired
    private ProductRepository productRepository;
    public static void main(String[] args) {

        SpringApplication.run(OrmDemoApplication.class, args);
    }

    @Override
    public void run(String... args) throws Exception {
        productRepository.save(new Product(null,"Computer",4300,3));
        productRepository.save(new Product(null,"Printer",1200,4));
        productRepository.save(new Product(null,"Smart Phone",3200,32));
        List<Product> products = productRepository.findAll();
        products.forEach(p->{
            System.out.println(p.toString());
        });
        Product product = productRepository.findById(Long.valueOf(1)).get();
        System.out.println("****************");
        System.out.println(product.getId());
        System.out.println(product.getName());
        System.out.println(product.getPrice());
        System.out.println(product.getQuantity());
        System.out.println("****************");
        System.out.println("-------------------");
        List<Product> productList = productRepository.findByNameContains("C");
        productList.forEach(c->{
            System.out.println(c.toString());
        });
        System.out.println("-----------------");
        List<Product> productList2 = productRepository.search("%r%");
        productList2.forEach(c->{
            System.out.println(c.toString());
        });

        Product product1 = productRepository.findById(Long.valueOf(2)).get();
        System.out.println("******************");
        product1.setId(6L);
        product1.setName("Laptop");
        product1.setPrice(5000L);
        product1.setQuantity(2);
        System.out.println("******************");

        productRepository.deleteById(2L);
    }
}
