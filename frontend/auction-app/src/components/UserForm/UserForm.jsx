
import './UserForm.css';
import { AuthContext } from '../../contexts/AuthContext';
import { useContext } from 'react';
import Button from '../Button/Button';

const UserForm = ({ handleSubmit, text, isOpen, setIsOpen }) => {

    const { creds, setCreds, authError } = useContext(AuthContext);

    const handleChange = (e) => {
        setCreds({ ...creds, [e.target.name]: e.target.value });
    }

    const handleUserSubmit = (e) => {
        e.preventDefault();
        handleSubmit();
    }

    return (
        <>
            <div className={`overlay ${isOpen ? "active" : ""}`} onClick={() => { setIsOpen(false) }} id="overlay"></div>
            <div className={`side-panel ${isOpen ? "active" : ""}`} onClick={() => setIsOpen(true)} >
                <form onSubmit={handleUserSubmit}>
                    <h2>{text}</h2>
                    <label htmlFor="username">Username</label>
                    <button className='user-button close-button' onMouseDown={() => setIsOpen(false)}>X</button>
                    <input type="text" name="username" value={creds.username} onChange={handleChange} />
                    <label htmlFor="password">Password</label>
                    <input type="password" name="password" value={creds.password} onChange={handleChange} />
                    {authError && (<p>{authError}</p>)}
                    <Button type="submit" text={text}/>
                </form>
            </div>
        </>
    )
}

export default UserForm;