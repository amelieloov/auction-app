
import { useContext, useEffect } from "react";
import { useParams } from "react-router-dom";
import AuctionForm from "../../components/AuctionForm/AuctionForm";
import { AuctionContext } from "../../contexts/AuctionContext";
import { getAuctionById } from "../../services/AuctionService";

const UpdateAuction = () => {

    const {updateAuction, setAuction, setPreviewUrl, setSelectedImage, setAuctionId} = useContext(AuctionContext);
    const {id} = useParams();
    
    useEffect(() => {
        const getAuction = async () => {
            const auction = await getAuctionById(id);
            setAuction(auction);
            setPreviewUrl(`https://localhost:7242${auction.image}`);
        }  

        getAuction();
    }, []);

    return(
        <AuctionForm handleSubmit={updateAuction} rubric="Update auction" buttonText="Update" />
    )
}

export default UpdateAuction;