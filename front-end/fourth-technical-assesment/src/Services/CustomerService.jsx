
const baseUrl = `${import.meta.env.VITE_API_BASE_URL}/Customers`;


export async function getCustomers(name){

    const fullUrl = name != "" ? `${baseUrl}?name=${name}` : baseUrl; 
    const result = await fetch(fullUrl);
    return result.json();
}

export async function getCusomerDetails(id){
  if (!id) {
    throw new Error("Id is required");
  }
    const fullUrl = `${baseUrl}/${id}`;
    const result = await fetch(fullUrl);
    return result.json();
}