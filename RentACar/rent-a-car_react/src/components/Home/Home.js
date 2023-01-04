
import LatestCars from "./LatestCars/LatestCars";


const Home = ({cars}) => {

    return (
       
        <section id="welcome-world">
            <div className="welcome-message">
                <h2>ALL new cars are here</h2>
            </div>

            <div id="home-page">
                <h1>Latest Cars</h1>

                {cars.length > 0
                    ? cars.map(x => <LatestCars key={x.id} car={x} />)
                    : <p className="no-articles">No cars yet</p>
                }
            </div>
        </section>
    );
};

export default Home;