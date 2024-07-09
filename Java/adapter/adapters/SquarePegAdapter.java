package Java.adapter.adapters;
import Java.adapter.round.Roundpeg;
import Java.adapter.square.SquarePeg;

public class SquarePegAdapter {
    private SquarePeg peg;

    public SquarePegAdapter(SquarePeg peg) {
        this.peg = peg;
    }

    @Override
    public double getRadius() {
        double result;

        result = (Math.sqrt(Math.pow((peg.getWidth() / 2), 2) * 2));
        return result;
    }
}
