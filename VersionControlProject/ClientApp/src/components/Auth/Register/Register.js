import "../Register/RegisterStyle.css"
import { useState } from "react";
import { register } from "../../../services/authService";

export default function Register() {
    const [inputObject, setInputObject] = useState({ userName: '', email: '', password: '', repeatPassword: '' });

    function handleOnFormSubmit(e) {
        e.preventDefault();

        register(inputObject)
            .then(res => console.log(res))
            .catch((error) => console.log(error));
    }

    return (
        <form className="auth-form" onSubmit={handleOnFormSubmit}>
            <div className="input-container">
                <label>Username</label>
                <input value={inputObject.userName} type="text" onChange={(e) => setInputObject({...inputObject, userName: e.target.value})}/>
            </div>
            <div className="input-container">
                <label>Email</label>
                <input value={inputObject.email} value={inputObject.email} type="text" onChange={(e) => setInputObject({ ...inputObject, email: e.target.value })} />
            </div>
            <div className="input-container">
                <label>Password</label>
                <input value={inputObject.password} type="password" onChange={(e) => setInputObject({ ...inputObject, password: e.target.value })} />
            </div>
            <div className="input-container">
                <label>Repat Password</label>
                <input value={inputObject.repeatPassword} type="password" onChange={(e) => setInputObject({ ...inputObject, repeatPassword: e.target.value })} />
            </div>
            <button type="submit">Register</button>
        </form>
    )
}