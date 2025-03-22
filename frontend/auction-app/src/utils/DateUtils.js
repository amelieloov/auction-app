export const formatDate = (date) => {
    const newDate = new Date(date);
    return newDate.toLocaleDateString("sv-SV", {
        year: "numeric",
        month: "short",
        day: "numeric",
        hour12: false,
        hour: "numeric",
        minute: "numeric",
    });
}