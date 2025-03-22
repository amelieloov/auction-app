
import './AuctionForm.css';
import { useContext } from 'react';
import { AuctionContext } from '../../contexts/AuctionContext';
import Button from '../Button/Button';

const AuctionForm = ({ handleSubmit, rubric, buttonText }) => {

    const { auction, setAuction, setPreviewUrl } = useContext(AuctionContext);

    const handleChange = (e) => {
        setAuction({ ...auction, [e.target.name]: e.target.value });
    }

    const handleFileChange = (e) => {
        const file = e.target.files[0];
        setAuction((prev) => ({
            ...prev,
            image: file,
        }));
        setPreviewUrl(URL.createObjectURL(file));
    };

    const handleAuctionSubmit = (e) => {
        e.preventDefault();
        handleSubmit();
    }

    return (
        <div className="center">
            <form onSubmit={handleAuctionSubmit} className="form-style">
                <h1>{rubric}</h1>

                <div className="unit">
                    <label htmlFor="title">Title</label>
                    <input className="title-input" type="text" name="auctionTitle" id="title" value={auction.auctionTitle} onChange={handleChange} />
                </div>
                <div className="unit">
                    <label htmlFor="description">Description</label>
                    <textarea className="description-input" type="text" name="auctionDescription" id="description" value={auction.auctionDescription} onChange={handleChange} />
                </div>
                <div className="unit">
                    <label htmlFor="price">Start price ($)</label>
                    <input className="price-input" type="number" name="auctionPrice" id="price" value={auction.auctionPrice} onChange={handleChange} />
                </div>
                <div className="unit">
                    <label htmlFor="endtime">End time</label>
                    <input className="date-input" type="datetime-local" name="endTime" id="endtime" value={auction.endTime} onChange={handleChange} />
                </div>
                <div className="unit">
                    <label htmlFor="image">Image</label>
                    <input type="file" accept="image/*" onChange={handleFileChange} name="image" id="image" />
                </div>
                <Button type="submit" text={buttonText} />
            </form>
        </div>
    )
}

export default AuctionForm;