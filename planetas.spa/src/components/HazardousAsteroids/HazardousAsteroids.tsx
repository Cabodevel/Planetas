import { FC, useEffect } from "react";
import hazardousAsteroidsContext from "../../context/hazardousAsteroidsContext";
import { HazardousContext } from "../../context/types";
import { useContextOrError } from "../../hooks/useContextOrError";
import HazardousAsteroidRowItem from "./HazardousAsteroidRowItem";
import { Table } from "./HazardousAsteroids.css";

const HazardousAsteroids: FC = () => {
  const asteroidsContext = useContextOrError<HazardousContext>(
    hazardousAsteroidsContext
  );

  const { hazardousAsteroidsData, getHazardousAsteroids } = asteroidsContext;

  useEffect(() => {
    const callAsync = async () => {
      await getHazardousAsteroids({
        planetName: "Earth",
      });
    };

    callAsync();
    console.log(hazardousAsteroidsData);
  }, []);

  return (
    <>
      <Table className="flex justify-content-around">
        <thead>
          <th>Name</th>
          <th>Diámetro</th>
          <th>Velocidad</th>
          <th>Fecha</th>
        </thead>
        <tbody>
          {hazardousAsteroidsData.hazardousAsteroids &&
            hazardousAsteroidsData.hazardousAsteroids.map((ha) => (
              <HazardousAsteroidRowItem key={ha.name} hazardousAsteroid={ha} />
            ))}
        </tbody>
      </Table>
    </>
  );
};

export default HazardousAsteroids;
