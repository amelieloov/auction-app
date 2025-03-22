
import { useParams } from "react-router-dom";
import AuctionCard from "../../components/AuctionCard/AuctionCard"
import { getAuctionById } from "../../services/AuctionService";
import { useEffect, useContext } from "react";
import { AuctionContext } from "../../contexts/AuctionContext";
import { BidContext } from "../../contexts/BidContext";
import './DetailedAuctionInfo.css';
import BidList from "../../components/BidList/BidList";
import { getBidsByUserID } from "../../services/BidService";

const DetailedAuctionInfo = () => {

    const { id } = useParams();
    const { auction, setAuction, checkIfClosed } = useContext(AuctionContext);
    const { bids, setBids } = useContext(BidContext);

    useEffect(() => {
        const getAuctions = async () => {
            const auction = await getAuctionById(id);
            setAuction(auction);
            setBids(auction.bids);
        }

        getAuctions();
    }, [id]);

    return (
        <div className="container">
            <div className="auction">
                <AuctionCard auction={auction} viewType="detailed" />
            </div>
            <div className="bidlist">
                {!checkIfClosed(auction.endTime) && bids.length > 0 && <h1 className="bid-title">Bid history</h1>}
                <BidList/>
            </div>
        </div>
    )
}

export default DetailedAuctionInfo;