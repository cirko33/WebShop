import { useState } from "react";
import authService from "../../services/authService"

const Login = () => {
    const [loginForm, setLoginForm] = useState({});

    const handleSubmit = (e) => {
        e.preventDefault();

        if(!loginForm.email || !loginForm.password) {
            alert("All fields required.")
            return;
        }

        authService.login(loginForm);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
            <label>Email:</label>
            <input
                type="email"
                id="email"
                value={loginForm.email}
                onChange={e => setLoginForm({...loginForm, email: e.target.value})}
                required
            />
            </div>
            <div>
            <label>Password:</label>
            <input
                type="password"
                id="password"
                value={loginForm.password}
                onChange={e => setLoginForm({...loginForm, password: e.target.value})}
                required
            />
            </div>
            <button type="submit">Login</button>
        </form>
    )
}

export default Login;