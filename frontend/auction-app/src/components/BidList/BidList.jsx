
import BidCard from "../BidCard/BidCard";
import { useContext } from "react";
import { BidContext } from "../../contexts/BidContext";
import './BidList.css';

const BidList = () => {

    const {bids} = useContext(BidContext);

    const bidList = bids.map(bid => {
        return(<BidCard key={bid.bidID} bid={bid}/>)
    });

    return(
        <div>
            {bids.length > 0 ? <ul className="bid-list-style">{bidList}</ul> : <p></p>}
        </div>
    )
}

export default BidList;