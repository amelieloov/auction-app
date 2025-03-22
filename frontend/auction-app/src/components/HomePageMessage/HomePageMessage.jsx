
import antiques from '../../images/antiques.png';
import './HomePageMessage.css';

const HomePageMessage = () => {

    return (
        <div className='outer-container'>
            <div className="image-container">
                <img className="center-image" src={antiques} alt="picture of antiques" />
                <h1 className='image-text'>Welcome!</h1>
            </div>
        </div>
    )
}

export default HomePageMessage;