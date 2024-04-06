package ma.emsi.roleuserjpa.service;

import jakarta.transaction.Transactional;
import lombok.AllArgsConstructor;
import ma.emsi.roleuserjpa.entities.Role;
import ma.emsi.roleuserjpa.entities.User;
import ma.emsi.roleuserjpa.repositories.RoleRepository;
import ma.emsi.roleuserjpa.repositories.UserRepository;
import org.springframework.stereotype.Service;

import java.util.UUID;

@Service
@Transactional
@AllArgsConstructor
public class UserServiceImpl implements UserService {
    private UserRepository userRepository;
    private RoleRepository roleRepository;
    @Override
    public User addNewUser(User user) {
        user.setUserId(UUID.randomUUID().toString());
        return userRepository.save(user);
    }

    @Override
    public Role addNewRole(Role role) {

        return roleRepository.save(role);
    }
    @Override
    public User findUserByUserName(String userName) {

        return userRepository.findByUsername(userName);
    }

    @Override
    public Role findRoleByRoleName(String roleName) {

        return roleRepository.findByRoleName(roleName);
    }

    @Override
    public void addRoleToUser(String username, String rolename) {
          User user=findUserByUserName(username);
          Role role=findRoleByRoleName(rolename);

              if(user.getRoles()!=null)
              {
                  user.getRoles().add(role);
                  role.getUsers().add(user);
              }


    }

    @Override
    public User authentificate(String username, String password) {
        User user=userRepository.findByUsername(username);
        if(user.getPassword().equals(password))
        {
            return user;
        }
        throw new RuntimeException("Bad credentials !");
    }
}
