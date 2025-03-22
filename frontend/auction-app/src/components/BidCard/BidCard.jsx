
import './BidCard.css';
import { useContext } from 'react';
import { BidContext } from '../../contexts/BidContext';
import { AuthContext } from '../../contexts/AuthContext';
import { useNavigate} from 'react-router-dom';

const BidCard = ({bid}) => {

    const {deleteBid} = useContext(BidContext);
    const {user} = useContext(AuthContext);
    const isCurrentUser = bid?.user?.userID === user?.userID;
    const navigate = useNavigate();

    return(<div className="bid-card">
        <h2>${bid.bidPrice}</h2>
        <h2 className='title' onClick={() => navigate(`/item/${bid?.auction?.auctionID}`)}>{bid?.auction?.auctionTitle}</h2> 
        <h2>{bid?.user?.userName && "by"} {bid?.user?.userName}</h2>
        {isCurrentUser && bid?.auction?.auctionID && <button className="bid-button" onMouseDown={() => deleteBid(bid.bidID)}>🗑️</button>}
    </div>)
}

export default BidCard;