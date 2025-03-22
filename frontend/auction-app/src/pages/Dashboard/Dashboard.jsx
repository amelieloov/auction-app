
import { useNavigate } from "react-router-dom";
import { useContext, useEffect } from "react";
import AuctionList from "../../components/AuctionList/AuctionList";
import { AuctionContext } from "../../contexts/AuctionContext";
import { BidContext } from "../../contexts/BidContext";
import BidList from "../../components/BidList/BidList";

import './Dashboard.css';

const Dashboard = () => {

    const navigate = useNavigate();
    const { auctions, getAuctionsByUser } = useContext(AuctionContext);
    const { getBidsByUser } = useContext(BidContext);

    useEffect(() => {
        const getAuctionsAndBids = async () => {
            getAuctionsByUser();
            getBidsByUser();
        }

        getAuctionsAndBids();
    }, [])

    return (
        <div className="dashboard">
            <div>
                <div className="top-part">
                    <h1 className="rubric">My auctions</h1>
                    <button className="button-style" onClick={() => navigate("/auction/add")}>Create New Auction</button>
                </div>
                <AuctionList auctionList={auctions} handleSearch={null} viewType="dashboard" />
            </div>
            <div>
                <h1 className="rubric">My bids</h1>
                <BidList />
            </div>
        </div>
    )
}

export default Dashboard;