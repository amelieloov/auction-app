import './AuctionCard.css';
import { formatDate } from '../../utils/DateUtils.js';
import { useNavigate } from 'react-router-dom';
import { useContext, useState } from 'react';
import { BidContext } from '../../contexts/BidContext.jsx';
import { AuctionContext } from '../../contexts/AuctionContext.jsx';
import { AuthContext } from '../../contexts/AuthContext.jsx';
import Button from '../Button/Button.jsx';

const AuctionCard = ({ auction, viewType }) => {

    const navigate = useNavigate();
    const { addBid } = useContext(BidContext);
    const { deleteAuction, checkIfClosed } = useContext(AuctionContext);
    const { user } = useContext(AuthContext);
    const [bidValue, setBidValue] = useState("");
    const isCurrentUser = auction?.user?.userID === user?.userID;
    const isClosed = checkIfClosed(auction.endTime);

    const handleChange = (e) => {
        setBidValue(e.target.value);
    }

    const handleAddBid = () => {
        addBid({ bidPrice: bidValue, auctionID: auction.auctionID });
        setBidValue("");
    }

    const cardClass =
        viewType === 'search' ? 'card-search' :
            viewType === 'detailed' ? 'card-detailed' :
                viewType = 'dashboard' ? 'card-dashboard' :
                    'card-default';

    return (
        <div className={`auction-card ${cardClass}`}>
            <div onMouseDown={() => navigate(`/item/${auction.auctionID}`)}>
                <img src={`https://localhost:7242/uploads/${auction.image}`} alt="No picture" />

                <h3>{auction.auctionTitle}</h3>
                <p>{!isClosed ? "Current price: " : "Final price: "} ${auction.auctionPrice}</p>

                {viewType === "detailed" && <div>
                    <p>Created {formatDate(auction.startTime)} {auction?.user?.userName && "by"} {auction?.user?.userName}</p>
                    <p>{!isClosed ? "Ends" : "Ended"} {formatDate(auction.endTime)}</p>
                    {isClosed && <h2>The auction has ended.</h2>}
                    {!isClosed && !isCurrentUser && <div className='add-bid'>
                        <input type="number" value={bidValue} onChange={handleChange} />
                        <Button type="button" onClick={handleAddBid} text="Add bid"/></div>}
                    <h3>Description:</h3>
                    <p> {auction.auctionDescription}</p>
                </div>}
            </div>

            {viewType === "card-dashboard" && <div className="auction-button">
                <button onMouseDown={() => navigate(`/auction/update/${auction.auctionID}`)}>✏️</button>
                <button onMouseDown={() => deleteAuction(auction.auctionID)}>🗑️</button>
            </div>}

        </div>
    )
}

export default AuctionCard;