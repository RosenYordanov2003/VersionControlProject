import { Route, Routes, useParams } from 'react-router-dom';
import Register from "../src/components/Auth/Register/Register";
import Navigation from "../src/components/Navigation/Navigation";

export default function App() {
    return (
        <>
            <Navigation/>
            <Routes>
                <Route path="/Register" element={<Register />} />
               {/* <Route path="/Login" element={<Login />} />*/}
            </Routes>
        </>
    )
}
