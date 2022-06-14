export type HazardousContext = {
  hazardousAsteroids: HazardousAsteroid[];
  getHazardousAsteroids: () => void;
};

export type HazardousAsteroid = {
  name: string;
  diameter: number;
  speed: number;
  date: Date;
};
