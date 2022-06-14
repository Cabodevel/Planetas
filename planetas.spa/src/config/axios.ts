import axios from "axios";

const hazardousAsteroidsClient = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
});
debugger;
export default hazardousAsteroidsClient;
