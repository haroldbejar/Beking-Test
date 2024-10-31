const baseUrl = "http://localhost:5082/api/";
const endPoints = {
  product: {
    base: `${baseUrl}Product`,
    list: `${baseUrl}Product/getallproducts`,
    byCategory: `${baseUrl}Product/getproductbycategory`,
  },
};
export default endPoints;
