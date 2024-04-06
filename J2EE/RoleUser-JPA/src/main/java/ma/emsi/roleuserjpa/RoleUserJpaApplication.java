package ma.emsi.roleuserjpa;

import ma.emsi.roleuserjpa.entities.Role;
import ma.emsi.roleuserjpa.entities.User;
import ma.emsi.roleuserjpa.service.UserService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import java.util.stream.Stream;

@SpringBootApplication
public class RoleUserJpaApplication {

    public static void main(String[] args) {
        SpringApplication.run(RoleUserJpaApplication.class, args);
    }

    @Bean
    CommandLineRunner start(UserService userService)    {
        return args -> {
            User u=new User();
            u.setUsername("User1");
            u.setPassword("123456");
            userService.addNewUser(u);

            User u1=new User();
            u1.setUsername("User2");
            u1.setPassword("123456");
            userService.addNewUser(u1);

            Stream.of("ETUDIANT","ADMIN","USER").forEach(r->{
                Role role=new Role();
                role.setRoleName(r);
                userService.addNewRole(role);
            });

            userService.addRoleToUser("User1","ETUDIANT");
            userService.addRoleToUser("User1","USER");
            userService.addRoleToUser("User2","ADMIN");
            userService.addRoleToUser("User2","USER");

            try {
                User user= userService.authentificate("User1","123456");
                System. out. println (user. getUserId() ) ;
                System. out. println (user. getUsername () ) ;
                System. out. println("Roles ==>") ;
                user. getRoles () .forEach(r-> {
                    System.out.println("role = " + r);
                });
            }
                catch (Exception e) {
                    e.printStackTrace();
                }



        };
    }

}
