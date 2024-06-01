import "../Register/RegisterStyle.css"
import { useState } from "react";


export default function Register() {
    const [inputObject, setInputObject] = useState({ username: '', email: '', password: '', repeatPassword: '' });

    function handleOnFormSubmit(e) {
        e.preventDefault();


    }

    return (
        <form className="auth-form" onSubmit={handleOnFormSubmit}>
            <div className="input-container">
                <label>Username</label>
                <input value={inputObject.username} type="text" onChange={(e) => setInputObject({...inputObject, username: e.target.value})}/>
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
        </form>
    )
}