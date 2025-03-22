
import './App.css'
import Navigation from './components/Navigation/Navigation';
import Main from './components/Main/Main';
import { getUser } from './services/UserService';
import { useEffect, useContext } from 'react';
import { AuthContext } from './contexts/AuthContext';
import UserForm from './components/UserForm/UserForm';
import { UIContext } from './contexts/UIContext';

function App() {

  const {setUser, handleLogin, handleAddUser, handleUpdateUser} = useContext(AuthContext);
  const {isLoginOpen, setIsLoginOpen, isRegisterOpen, setIsRegisterOpen, isUpdateOpen, setIsUpdateOpen} = useContext(UIContext);

  useEffect(() => {
    const GetUserInfo = async () => {
      var user = await getUser();
      setUser(user);
    }

    GetUserInfo();
  }, [])

  return (
    <>
      <Navigation />
      <Main />

       {/* Initially hidden */}
      <UserForm handleSubmit={handleLogin} text="Login" isOpen={isLoginOpen} setIsOpen={setIsLoginOpen}/>
      <UserForm handleSubmit={handleAddUser} text="Register" isOpen={isRegisterOpen} setIsOpen={setIsRegisterOpen}/>
      <UserForm handleSubmit={handleUpdateUser} text="Edit Profile" isOpen={isUpdateOpen} setIsOpen={setIsUpdateOpen}/>
    </>
  )
}

export default App
