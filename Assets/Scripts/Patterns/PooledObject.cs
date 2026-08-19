using UnityEngine;
using UnityEngine.Events;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private UnityEvent OnReset;

    ObjectPool pool;

    private float timer;
    private bool setToRecycle = false;
    private float recycleTime = 0;

    public void SetObjectPool(ObjectPool pool)
    {
        this.pool = pool;
        timer = 0;
        recycleTime = 0;
        setToRecycle = false;
    }

    private void Update()
    {
        if(setToRecycle)
        {
            timer += Time.deltaTime;

            if(timer >= recycleTime)
            {
                setToRecycle = false;
                timer = 0;
                Recycle();
            }
        }
    }

    public void ResetObject()
    {
        OnReset?.Invoke();
    }

    public void Recycle()
    {
        if(pool != null)
        {
            pool.RestoreObject(this);
        }
    }

    public void Recycle(float time)
    {
        setToRecycle = true;
        recycleTime = time;
    }
}