import axios from "axios";

const hazardousAsteroidsClient = axios.create({
  baseURL: process.env.API_ENDPOINT,
});

export default hazardousAsteroidsClient;
