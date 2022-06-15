import { FC, useEffect } from "react";
import hazardousAsteroidsContext from "../../context/hazardousAsteroidsContext";
import { HazardousContext } from "../../context/types";
import { useContextOrError } from "../../hooks/useContextOrError";

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
      <div>Test component</div>
      {hazardousAsteroidsData.hazardousAsteroids &&
        hazardousAsteroidsData.hazardousAsteroids.map((ha) => (
          <div key={ha.name}>{ha.name}</div>
        ))}
    </>
  );
};

export default HazardousAsteroids;
