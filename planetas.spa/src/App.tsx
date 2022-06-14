import React from "react";
import HazardousAsteroids from "./components/HazardousAsteroids/HazardousAsteroids";
import HazardousAsteroidsProvider from "./context/HazardousAsteroidsProvider";

function App() {
  return (
    <React.StrictMode>
      <HazardousAsteroidsProvider>
        <HazardousAsteroids />
      </HazardousAsteroidsProvider>
    </React.StrictMode>
  );
}

export default App;
