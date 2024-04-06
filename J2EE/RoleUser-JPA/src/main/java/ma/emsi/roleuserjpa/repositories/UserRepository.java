package ma.emsi.roleuserjpa.repositories;

import ma.emsi.roleuserjpa.entities.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<User,String> {
    User findByUsername(String userName);
}
