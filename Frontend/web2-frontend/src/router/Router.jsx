import { Navigate, Route, Routes } from "react-router-dom";
import Login from "../components/Login/Login";
import Register from "../components/Register/Register";
import Dashboard from "../components/Dashboard/Dashboard";
import AuthContext from "../contexts/auth-context";
import { useContext } from "react";
import Profile from "../components/Profile/Profile";

const Router = () => {
    const context = useContext(AuthContext);
    
    return (  
        <Routes>
            <Route path="/" element={context.token ? <Navigate to="/home"/> : <Login />} />
            <Route path="/register" element={context.token ? <Navigate to="/home"/> : <Register />}/>
            <Route path="/home" element={context.token ? <Dashboard /> : <Navigate to="/"/>} />
            <Route path="/profile" element={context.token ? <Profile /> : <Navigate to="/"/>} />
        </Routes>
    );
}
 
export default Router;