import { FC, useEffect } from "react";
import hazardousAsteroidsContext from "../../context/hazardousAsteroidsContext";
import { HazardousContext } from "../../context/types";
import { useContextOrError } from "../../hooks/useContextOrError";

const HazardousAsteroids: FC = () => {
  const asteroidsContext = useContextOrError<HazardousContext>(
    hazardousAsteroidsContext
  );

  const { hazardousAsteroids, getHazardousAsteroids } = asteroidsContext;

  useEffect(() => {
    getHazardousAsteroids();
    console.log(hazardousAsteroids);
  });

  return (
    <>
      <div>Test component</div>
      {hazardousAsteroids &&
        hazardousAsteroids.map((ha) => <div key={ha.name}>{ha.name}</div>)}
    </>
  );
};

export default HazardousAsteroids;
