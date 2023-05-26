import React, { useEffect, useState } from "react";
import api from "../api/api";
import jwtDecode from "jwt-decode";
import {useNavigate} from 'react-router-dom'

const AuthContext = React.createContext({
    token: null,
    onLogout: () => {},
    // eslint-disable-next-line no-unused-vars
    onLogin: (loginData) => {},
});

export const AuthContextProvider = (props) => {
    const [token, setToken] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        setToken(localStorage.getItem('token'));
    }, []);

    const loginHandler = async(loginData) => {
        try {
            const res = await api.post('/auth/login', loginData)
            if(!res)
                return;

            setToken(res.data.token);
            localStorage.setItem('token', res.data.token); 
            navigate("/home")
        } catch (e){
            alert(e.response.data.Exception);
        }
    };

    const logoutHandler = () => {
        setToken(null);
        localStorage.clear();
        navigate("/")
    };

    const userType = () => {
        try {
            if(!token)
                return null;
            const tokenDecoded = jwtDecode(token);
            return tokenDecoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        } catch(e) {
            console.log(e);
        }
    };

    return (
        <AuthContext.Provider
        value={{
            token: token,
            onLogout: logoutHandler,
            onLogin: loginHandler,
            type: userType
        }}>
            
            {// eslint-disable-next-line react/prop-types
                props.children
            }       
        </AuthContext.Provider>
    );
};

export default AuthContext;