import { useState, useEffect, useContext, createContext } from "react";
import { useNavigate } from "react-router-dom";
import { UIContext } from "./UIContext";
import { toast } from "react-hot-toast";
import { loginUser } from "../services/UserService";
import { createUser } from "../services/UserService";
import { updateUser } from "../services/UserService";
import { getUser } from "../services/UserService";

export const AuthContext = createContext();

const AuthProvider = (props) => {

    const [creds, setCreds] = useState({ username: "", password: "" });
    const storedIsLoggedIn = localStorage.getItem('isLoggedIn') === 'true';
    const [isLoggedIn, setIsLoggedIn] = useState(storedIsLoggedIn);
    const [user, setUser] = useState({});
    
    const {setIsLoginOpen, setIsRegisterOpen, setIsUpdateOpen} = useContext(UIContext);
    const navigate = useNavigate();
  
    useEffect(() => {
      localStorage.setItem('isLoggedIn', isLoggedIn);
    }, [isLoggedIn]);

    const handleLogin = async () => {
        try{
            const result = await loginUser(creds);
            if(result){
                setIsLoginOpen(false);
                setIsLoggedIn(true);
                var currentUser = await getUser();
                setUser(currentUser);
                setCreds({ username: "", password: "" });
            }
            toast.success('Successfully logged in.');
        } catch (error){
            toast.error(error.message);
        }
    }

    const handleLogout = () => {
        setIsLoggedIn(false);
        localStorage.removeItem('AuthToken');
        navigate("/");
    };

    const handleAddUser = async () => {
        try{
            await createUser(creds);
            setIsRegisterOpen(false);
            setCreds({ username: "", password: "" });
            toast.success("User successfully registrated.")
        } catch (error){
            toast.error(error.message);
        }
    }

    const handleUpdateUser = async () => {
        try {
            await updateUser(creds);
            setIsUpdateOpen(false);
            setCreds({ username: "", password: "" });
            toast.success("User successfully updated.")
        } catch (error) {
            toast.error(error.message);
        }
    }

    return (<AuthContext.Provider value={{ creds, setCreds, isLoggedIn, setIsLoggedIn, handleLogin, handleLogout, 
    user, setUser, handleAddUser, handleUpdateUser }}>
        {props.children}
    </AuthContext.Provider>)
}

export default AuthProvider;