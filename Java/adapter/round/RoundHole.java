package Java.adapter.round;

public class RoundHole {
    private double radius;
    public RoundHole(double radius) {
        this.radius = radius;
    }

    public double getRadius() {
        return radius;
    }

    public boolean  fits(Roundpeg peg){
        boolean result;
        result = (this.getRadius()) >= peg.getRadius();
        return result;
    }
}