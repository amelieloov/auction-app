export const addBid = async (bidData) => {
    try {
      const response = await fetch("https://localhost:7242/api/Bid", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${localStorage.getItem("AuthToken")}`,
        },
        body: JSON.stringify(bidData),
      });
  
      if (!response.ok) {
        const data = await response.json();
        throw new Error(data.message || "An unexpected error occurred.");
      }

    } catch (error) {
      throw(error);
    }
  };


  export const deleteBid = async (id) => {

    console.log("bidid", id)
    try {
      const response = await fetch(`https://localhost:7242/api/Bid?bidId=${id}`, {
        method: "DELETE",
        headers: {
          "Authorization": `Bearer ${localStorage.getItem("AuthToken")}`,
        }
      });
  
      if (!response.ok) {
        const data = await response.json();
        throw new Error(data.message || "An unexpected error occurred.");
      }
      
    } catch (error) {
      throw(error);
    }
  };

  export const getBidsByUserID = async () => {

    const data = await fetch(`https://localhost:7242/api/Bid`, {
      headers: {
          "Authorization": `Bearer ${localStorage.getItem("AuthToken")}`,
      },
    }).then(response => response.json());

    console.log("bidsbyuserid", data);

    return data;
}