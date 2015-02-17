
class MyClass
{
    protected int myNumber;
    public abstract int numbers
    {
        get;
        set;
    }
}

class MyDerived:MyClass
{
   
    public override int numbers
    {
        get
        {
            return myNumber;
        }
        set
        {
            myNumber = value;
        }
    }
}
