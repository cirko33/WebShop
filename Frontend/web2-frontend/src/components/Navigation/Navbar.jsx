import { useContext } from 'react';
import './styles.css';
import AuthContext from "../../contexts/auth-context";
import { Link } from 'react-router-dom';

const Navbar = () => {
  const context = useContext(AuthContext);

  const handleLogout = (e) => {
    e.preventDefault();
    context.onLogout();
  }

  return (
    <nav className="navbar">
      <ul>
        <li> 
          { context.token &&  <button onClick={handleLogout}>Logout</button> } 
          { !context.token && <Link to="/">Login</Link> }
        </li>
        <li> 
          { context.token &&  <Link to="/profile">Profile</Link> } 
          { !context.token && <Link to="/register">Register</Link> }
        </li>
      </ul>
    </nav>
  );
};

export default Navbar;